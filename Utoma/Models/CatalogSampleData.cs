using System.Linq;
using System.Collections.Generic;

using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace Utoma.Models
{
    public class CatalogSampleData
    {
        
        public static void FillUp(IApplicationBuilder app)
        {
            CatalogDbContext context = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<CatalogDbContext>();
            
            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }

            if (!context.periodicals.Any())
            {
                //context.Database. ExecuteSqlCommand("TRUNCATE TABLE [Categories]");
                //context.SaveChanges();

                //Categorie
                var categoriesMemory = new List<Category>
                {
                    new Category { CategoryName = "Автомобили" },
                    new Category { CategoryName = "Быт и семья" },
                    new Category { CategoryName = "Детские и молодёжные" },
                    new Category { CategoryName = "Для родителей" },
                    new Category { CategoryName = "Объявления" },
                    new Category { CategoryName = "Разное" }
                };

                new List<Category>
                {
                    categoriesMemory[0],
                    categoriesMemory[1],
                    categoriesMemory[2],
                    categoriesMemory[3],
                    categoriesMemory[4],
                    categoriesMemory[5]
                }.ForEach(category => context.categories.Add(category));



                //Publication Type
                var publicationTypesMemory = new List<PublicationType>
                {
                    new PublicationType { PublicationTypeName = "Газета" },
                    new PublicationType { PublicationTypeName = "Журнал 3+" },
                    new PublicationType { PublicationTypeName = "Журнал 7+" },
                    new PublicationType { PublicationTypeName = "Журнал 16+" }
                };

                new List<PublicationType>
                {
                    publicationTypesMemory[0],
                    publicationTypesMemory[1],
                    publicationTypesMemory[2],
                    publicationTypesMemory[3]
                }.ForEach(pt => context.publicationTypes.Add(pt));



            //Publisher
                var publishersMemory = new List<Publisher>
                {
                    new Publisher { PublisherName = "АБВГД-медиа" },
                    new Publisher { PublisherName = "ТОО Издательский дом УтопиаТайм" },
                    new Publisher { PublisherName = "FreePub" }
                };

                new List<Publisher>
                {
                    publishersMemory[0],
                    publishersMemory[1],
                    publishersMemory[2]
                }.ForEach(p => context.publishers.Add(p));



            //Periodical

                context.periodicals.AddRange(

                new Periodical
                {
                    ISSN = "2000-0001",
                    Name = "1000 советов",
                    Category = categoriesMemory.Single(c => c.CategoryName == "Быт и семья"),
                    PublicationType = publicationTypesMemory.Single(t => t.PublicationTypeName == "Журнал 16+"),
                    NumPages = 30,
                    TimesInMonth = 1,
                    Publisher = publishersMemory.Single(p => p.PublisherName == "ТОО Издательский дом УтопиаТайм"),
                    Price = 45.00M,
                    Description = "1000 Советов — народный журнал, предназначенный для народа. Он содержит советы на все случаи жизни, которые обязательно пригодятся каждому человеку. И совсем не имеет значения, какой деятельностью вы занимаетесь и чем увлекаетесь, ведь в журнале содержится много полезной информации из самых различных направлений: домоводство, кулинария, юриспруденция, садоводство, здоровье, хобби, воспитание детей, психология, красота и многое-многое другое.",
                    CoverImage = "/img/cat/covers/1000sovetov_N19.jpg",
                    Thumbnail = "/img/cat/thumb/th_1000sovetov_N19.jpg"
                },

                new Periodical
                {
                    ISSN = "2000-0002",
                    Name = "Апперкот",
                    Category = categoriesMemory.Single(c => c.CategoryName == "Объявления"),
                    PublicationType = publicationTypesMemory.Single(t => t.PublicationTypeName == "Газета"),
                    NumPages = 40,
                    TimesInMonth = 1,
                    Publisher = publishersMemory.Single(p => p.PublisherName == "ТОО Издательский дом УтопиаТайм"),
                    Price = 34.00M,
                    Description = "Реклама, смешные анекдоты и гороскоп. Без политики! Читайте в свежем выпуске газеты",
                    CoverImage = "/img/cat/covers/apperkot_2011-40.jpg",
                    Thumbnail = "/img/cat/thumb/apperkot_2011-40.jpg"
                },

                new Periodical
                {
                    ISSN = "2000-0003",
                    Name = "Автомобили мира",
                    Category = categoriesMemory.Single(c => c.CategoryName == "Автомобили"),
                    PublicationType = publicationTypesMemory.Single(t => t.PublicationTypeName == "Журнал 16+"),
                    NumPages = 40,
                    TimesInMonth = 1,
                    Publisher = publishersMemory.Single(p => p.PublisherName == "FreePub"),
                    Price = 120.00M,
                    Description = "Это изданный на высшем уровне альбом с наиболее полной русскоязычной информацией обо всех марках машин, выпускаемых в мире, будь то Китай, Япония, Америка, Россия и другие страны света. На страницах каталога вы познакомитесь с новыми мощными внедорожниками, элегантными легковыми машинами, пикапами, минивэнами, развозными фургонами для успешного бизнеса и в десятках и сотнях вариаций. Журнал-каталог Автомобили мира демонстрирует, прежде всего, максимально высокий уровень информативности и оперативности плюс всегда великолепное качество иллюстративного материала. Предназначен для всех, кто регулярно следит за автоновинками и хотел бы быть в курсе всех событий, знать тенденции и направления в среде автомобилестроения.",
                    CoverImage = "/img/cat/covers/avtomobili_mira_2012.jpg",
                    Thumbnail = "/img/cat/thumb/avtomobili_mira_2012.jpg"
                },

                new Periodical
                {
                    ISSN = "2000-0004",
                    Name = "Автозвук",
                    Category = categoriesMemory.Single(c => c.CategoryName == "Автомобили"),
                    PublicationType = publicationTypesMemory.Single(t => t.PublicationTypeName == "Журнал 16+"),
                    NumPages = 40,
                    TimesInMonth = 1,
                    Publisher = publishersMemory.Single(p => p.PublisherName == "ТОО Издательский дом УтопиаТайм"),
                    Price = 80.00M,
                    Description = "Наша тема - звук и мультимедиа в автомобиле. Про это мы знаем очень много, каждый день узнаём ещё больше и тем, что узнали, делимся с вами. Делимся результатами тестов автомобильной аудио-видеотехники, деелимся впечатлениями от систем в автомобилях, построенных профессиональными студиями и любителями-энтузиастами...",
                    CoverImage = "/img/cat/covers/avtoZvuk_2013-07.jpg",
                    Thumbnail = "/img/cat/thumb/avtoZvuk_2013-07.jpg"
                },

                new Periodical
                {
                    ISSN = "2000-0005",
                    Name = "Домашний",
                    Category = categoriesMemory.Single(c => c.CategoryName == "Быт и семья"),
                    PublicationType = publicationTypesMemory.Single(t => t.PublicationTypeName == "Журнал 16+"),
                    NumPages = 40,
                    TimesInMonth = 1,
                    Publisher = publishersMemory.Single(p => p.PublisherName == "АБВГД-медиа"),
                    Price = 60.00M,
                    Description = "Журнал для всей семьи! В каждом номере — секреты красоты и здоровья, домашнего уюта, кулинарные советы, рекомендации астролога, уход за домашними питомцами, семейная психология, юридическая консультация, житейские истории и многое-многое другое. Также на страницах журнала вас ждут интересные интервью с любимыми звездами шоу-бизнеса и кино, где они делятся секретами личной жизни и профессионального успеха, рассказывают о доме, семье и детях.",
                    CoverImage = "/img/cat/covers/domashnij-3-2022-01.jpg",
                    Thumbnail = "/img/cat/thumb/domashnij-3-2022-01.jpg"
                },

                new Periodical
                {
                    ISSN = "2000-0006",
                    Name = "Из рук в руки",
                    Category = categoriesMemory.Single(c => c.CategoryName == "Объявления"),
                    PublicationType = publicationTypesMemory.Single(t => t.PublicationTypeName == "Газета"),
                    NumPages = 24,
                    TimesInMonth = 4,
                    Publisher = publishersMemory.Single(p => p.PublisherName == "FreePub"),
                    Price = 16.00M,
                    Description = "Газета Объявления из рук в руки: все объявления из рук в руки, никакой воды! Сплошная ярмарка объявлений и быстрый поиск, экспресс-подача!",
                    CoverImage = "/img/cat/covers/iz_ruk_v_ruki_2009-07-06.jpg",
                    Thumbnail = "/img/cat/thumb/iz_ruk_v_ruki_2009-07-06.jpg"
                },

                new Periodical
                {
                    ISSN = "2000-0007",
                    Name = "Дневник стрекозы",
                    Category = categoriesMemory.Single(c => c.CategoryName == "Детские и молодёжные"),
                    PublicationType = publicationTypesMemory.Single(t => t.PublicationTypeName == "Журнал 7+"),
                    NumPages = 40,
                    TimesInMonth = 1,
                    Publisher = publishersMemory.Single(p => p.PublisherName == "АБВГД-медиа"),
                    Price = 48.00M,
                    Description = "Дневник Стрекозы - журнал для юных модниц. Являясь дополнением к журналу Стрекоза, он собрал в себе много интересного: анкеты для подружек, прикольные тесты, гороскопы, странички для секретов, полезняшки, интересные задания, конкурс Подружки Стрекозы, конкурсы, подарки, плакат в каждом номере!",
                    CoverImage = "/img/cat/covers/pr_dnevnik-strekozy_2022-06-10.png",
                    Thumbnail = "/img/cat/thumb/pr_dnevnik-strekozy_2022-06-10.png"
                },

                new Periodical
                {
                    ISSN = "2000-0008",
                    Name = "Маленькие академики",
                    Category = categoriesMemory.Single(c => c.CategoryName == "Детские и молодёжные"),
                    PublicationType = publicationTypesMemory.Single(t => t.PublicationTypeName == "Журнал 3+"),
                    NumPages = 32,
                    TimesInMonth = 1,
                    Publisher = publishersMemory.Single(p => p.PublisherName == "АБВГД-медиа"),
                    Price = 48.00M,
                    Description = "Маленькие академики - это не сборник научных открытий. Это познавательный журнал! Всё, что ребенок узнает в своем возрасте – уже способствует его развитию. А обучение через игру – двойная польза. Пройти лабиринт пирамиды Хеопса, путешествуя по Египту. Или раскрасить необычную рыбу, знакомясь с морем и его обитателями. Увлечённые процессом, дети не только запоминают занимательные факты, но и развивают мелкую моторику, логику, воображение.",
                    CoverImage = "/img/cat/covers/pr_malenkie-akademiki_2022-05.jpeg",
                    Thumbnail = "/img/cat/thumb/pr_malenkie-akademiki_2022-05.jpeg"
                },

                new Periodical
                {
                    ISSN = "2000-0009",
                    Name = "Непоседа",
                    Category = categoriesMemory.Single(c => c.CategoryName == "Детские и молодёжные"),
                    PublicationType = publicationTypesMemory.Single(t => t.PublicationTypeName == "Журнал 3+"),
                    NumPages = 32,
                    TimesInMonth = 2,
                    Publisher = publishersMemory.Single(p => p.PublisherName == "АБВГД-медиа"),
                    Price = 48.00M,
                    Description = "Увлекательные истории, яркие иллюстрации и много-много заданий. Если в двух словах, то интересно и полезно. Если подробнее, то готовьтесь - будет #многобукв. Журнал Непоседа - это прежде всего главные герои. Девочка Гера, весёлый крыс Озорник, космический герой Жевжик, Пират Маратыч и, конечно, сам Непоседа. Они всегда чем-то заняты, так что легко найдут занятие и для Вашего ребёнка.",
                    CoverImage = "/img/cat/covers/pr_neposeda_2022-05.jpeg",
                    Thumbnail = "/img/cat/thumb/pr_neposeda_2022-05.jpeg"
                },

                new Periodical
                {
                    ISSN = "2000-0010",
                    Name = "Работа сегодня",
                    Category = categoriesMemory.Single(c => c.CategoryName == "Объявления"),
                    PublicationType = publicationTypesMemory.Single(t => t.PublicationTypeName == "Газета"),
                    NumPages = 28,
                    TimesInMonth = 4,
                    Publisher = publishersMemory.Single(p => p.PublisherName == "FreePub"),
                    Price = 18.00M,
                    Description = "Самые новые вакансии! Быстрый и удобный поиск среди 44.000+ вакансий",
                    CoverImage = "/img/cat/covers/rabota_segodnya_2015-10-06.jpg",
                    Thumbnail = "/img/cat/thumb/rabota_segodnya_2015-10-06.jpg"
                },

                new Periodical
                {
                    ISSN = "1991-0011",
                    Name = "Семья и школа",
                    Category = categoriesMemory.Single(c => c.CategoryName == "Для родителей"),
                    PublicationType = publicationTypesMemory.Single(t => t.PublicationTypeName == "Журнал 16+"),
                    NumPages = 40,
                    TimesInMonth = 1,
                    Publisher = publishersMemory.Single(p => p.PublisherName == "FreePub"),
                    Price = 84.00M,
                    Description = "Старейший журнал, посвященный вопросам жизни и воспитания. Читатели находят в Семье и школе то, что необходимо знать о развитии и воспитании ребенка с младенчества до совершеннолетия современного ребенка в современном обществе. На страницах журнала идет речь о подготовке к школе, о школьных трудностях, о проблемах подростка, о детях одаренных и детях трудных, о зонах опасности и группах риска; особое внимание - здоровью ребенка. Журнал рассказывает об изменениях, происходящих в школе, о различных подходах к обучению, о новых программах, об участии родителей в школьной жизни, о возможных конфликтах семьи и школы и способах их разрешения.",
                    CoverImage = "/img/cat/covers/semja_i_shkola_1991-03.jpg",
                    Thumbnail = "/img/cat/thumb/semja_i_shkola_1991-03.jpg"
                }


                );
            }

            context.SaveChanges();

        }

    }
}
