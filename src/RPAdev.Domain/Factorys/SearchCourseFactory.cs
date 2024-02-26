using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using RPAdev.Domain.Interfaces;
using RPAdev.Domain.Models;
using RPAdev.Domain.Shared;

namespace RPAdev.Domain.Factorys;

public class SearchCourseFactory : ISearchCourseFactory
{
    private IWebDriver _pgMain;
    private IWebDriver _pgCourse;
    private readonly ICourseRepository _courseRep;

    public SearchCourseFactory(ICourseRepository courseRep)
    {
        _courseRep = courseRep;
    }


    public async Task<Response> Search(string search)
	{
        var response = new Response();

        try
        {
            string url = $"https://www.alura.com.br/busca?query={search}";

            ChromeOptions options = new();
            options.AddArgument("--disable-notifications");

            _pgMain = new ChromeDriver(options);

            await _pgMain.MinimizeAndGoToUrl(url);

            //retorna a lista de cursos (lista de <li>)
            var courses = _pgMain.FindElementsByXPath("//*[@id='busca-resultados']/ul/li");

            var searchUpper = search.ToUpper();

            var addNew = false;

            foreach (var c in courses)
            {
                if (c.Text.Contains("Formação"))
                {
                    string courseTitle = c.GetTextByClass("busca-resultado-nome").ToUpper();

                    //se o BD já contém o curso/formação, pula para o próximo
                    if (await _courseRep.AnyAsync(c => c.Title == courseTitle))
                        continue;

                    //Obtém o link do curso dentro do elemento <li>
                    var linkCourse = c.GetAttributeByTag("href", "a");

                    string courseDuration = "N/A";
                    string courseDescription = "N/A";
                    string courseTeachers = "N/A";

                    using (_pgCourse = new ChromeDriver(options))
                    {
                        await _pgCourse.MinimizeAndGoToUrl(linkCourse);

                        //Obtendo a duração do curso
                        try
                        {
                            courseDuration = _pgCourse.GetTextByClass("formacao__info-destaque");
                        }
                        catch (Exception) { }

                        //Obtendo a descrição do curso
                        try
                        {
                            courseDescription = _pgCourse.GetTextByClass("formacao-descricao-texto");
                        }
                        catch (Exception) { }

                        //Obtendo os professores do curso
                        try
                        {
                            courseTeachers = _pgCourse.GetTextOfElementsByClass("formacao-instrutor-nome");
                        }
                        catch (Exception) { }
                    };

                    await _courseRep.AddAsync(new Course(courseTitle, courseTeachers, courseDuration, courseDescription));
                    await _courseRep.SaveChanges();

                    addNew = true;

                    break;
                }
                else if (c.Text.Contains("Curso"))
                {
                    //Obtendo nome e descrição do curso
                    string courseTitle = c.GetTextByClass("busca-resultado-nome").ToUpper();
                    string courseDescription = c.GetTextByClass("busca-resultado-descricao");

                    //se o BD já contém o curso/formação, pula para o próximo
                    if (await _courseRep.AnyAsync(c => c.Title == courseTitle))
                        continue;

                    //Obtém o link do curso dentro do elemento <li>
                    var linkCourse = c.GetAttributeByTag("href", "a");

                    string courseDuration = "N/A";
                    string courseTeachers = "N/A";

                    using (_pgCourse = new ChromeDriver(options))
                    {
                        await _pgCourse.MinimizeAndGoToUrl(linkCourse);

                        //Obtendo a duração do curso
                        try
                        {
                            courseDuration = _pgCourse.GetTextByXPath("/html/body/section[1]/div/div[2]/div[1]/div/div[1]/div/p[1]");
                        }
                        catch (Exception) { }


                        //Obtendo os professores do curso
                        try
                        {
                            courseTeachers = _pgCourse.GetTextByClass("instructor-title--name");
                        }
                        catch (Exception) { }
                    };

                    await _courseRep.AddAsync(new Course(courseTitle, courseTeachers, courseDuration, courseDescription));
                    await _courseRep.SaveChanges();

                    addNew = true;

                    break;
                }
            }

            _pgMain.Dispose();

            if (addNew)
            {
                response.IsSuccessful = true;
                response.Message = "Curso adicionado com sucesso!";
            }
            else
            {
                response.IsSuccessful = false;
                response.Message = "Não existe um novo curso com o termo pesquisado.";
            }

        }
        catch (Exception ex)
        {
            response.IsSuccessful = false;
            response.Message = $"Ocorreu um erro ao tentar buscar o curso: {ex.Message}";
        }
        finally
        {
            if(_pgCourse != null) _pgCourse.Dispose();
            if(_pgMain != null) _pgMain.Dispose();
        }

        return response;
    }


}
