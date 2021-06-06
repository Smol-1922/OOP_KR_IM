using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace ООП_КР_ИМ
{
    class Program
    {

        static void Main(string[] args)
        {
            string Name;
            Console.WriteLine("Введите название текстового файла, он создаться на рабочем столе\n");
            Name=Console.ReadLine();
            string logPath = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.Desktop),Name+=".txt");
            StreamWriter tw = new StreamWriter(logPath);
            Random random = new Random(Guid.NewGuid().GetHashCode());
            List<Request> que_1= new List<Request>();
            List<Request> que_2= new List<Request>();
            List<Master> list_master_hair = new List<Master>();
            List<Master> list_master_manicure = new List<Master>();
            int number_2=3;
            int number_1=5;
            int step=30;
            int chance_h=70;
            int chance_m=30;
            int chance_2=70;
            int cost_hair=800;
            int cost_man=1700;
            int servis_time_hair=40;
            int servis_time_man=120;
            int temp;
            for (; ; )
            {
                Console.WriteLine("Хотите ли вы задать значения самостоятельно:\n");
                Console.WriteLine("1.Да\n");
                Console.WriteLine("2.Нет\n");
                int.TryParse(Console.ReadLine(), out temp);
                if (temp == 1 || temp == 2)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Вы ввели некорректные данные\n");
                }
            }
            if (temp == 1)
            {
                for (; ; )
                {
                    Console.WriteLine("Введите кол-во мастеров, в зале стрижки от 2 до 5\n");
                    int.TryParse(Console.ReadLine(), out number_2);
                    if (2 <= number_2 && number_2 <= 5)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Вы ввели некорректные данные\n");
                    }
                }
                for (; ; )
                {
                    Console.WriteLine("Введите кол-во мастеров, в зале маникюра от 2 до 5\n");
                    int.TryParse(Console.ReadLine(), out number_1);
                    if (2 <= number_1 && number_1 <= 5)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Вы ввели некорректные данные\n");
                    }
                }
                for (; ; )
                {
                    Console.WriteLine("Введите шаг иметации он должен находиться в диапазоне от 15 до 30 минут\n");
                    int.TryParse(Console.ReadLine(), out step);
                    if (15 <= step && step <= 30)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Вы ввели некорректные данные\n");
                    }
                }
                for (; ; )
                {
                    Console.WriteLine("Введите вероятность выбора стрижки в заявке от 1% до 99%\n");
                    if (int.TryParse(Console.ReadLine(), out chance_h))
                    {
                        chance_m = 100 - chance_h;
                    }
                    if (1 <= chance_h && chance_h <= 99)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Вы ввели некорректные данные\n");
                    }
                }
                for (; ; )
                {
                    Console.WriteLine("Введите вероятность выбора 2 услуг\n");
                    int.TryParse(Console.ReadLine(), out chance_2);
                    if (0 <= chance_2 && chance_2 <= 100)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Вы ввели некорректные данные\n");
                    }
                }
                for (; ; )
                {
                    Console.WriteLine("Введите стоимость стрижки\n");
                    int.TryParse(Console.ReadLine(), out cost_hair);
                    if (0 < cost_hair)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Вы ввели некорректные данные\n");
                    }
                }
                for (; ; )
                {
                    Console.WriteLine("Введите стоимость маникюра\n");
                    int.TryParse(Console.ReadLine(), out cost_man);
                    if (0 < cost_man)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Вы ввели некорректные данные\n");
                    }
                }
                for (; ; )
                {
                    Console.WriteLine("Введите время ослуживания в зале стрижки в диапазоне от 20 минут до 180 минут\n");
                    int.TryParse(Console.ReadLine(), out servis_time_hair);
                    if (20 <= servis_time_hair && servis_time_hair <= 180)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Вы ввели некорректные данные\n");
                    }
                }
                for (; ; )
                {
                    Console.WriteLine("Введите время ослуживания в зале маникюра в диапазоне от 20 минут до 180 минут\n");
                    int.TryParse(Console.ReadLine(), out servis_time_man);
                    if (20 <= servis_time_man && servis_time_man <= 180)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Вы ввели некорректные данные\n");
                    }
                }
            }
            Hall Hall_haircup = new Hall(number_2, number_1, 0, que_1, Service.haircut, list_master_hair);
            Hall Hall_manicure = new Hall(number_1, number_2, 0, que_2, Service.manicure, list_master_manicure);
            function f = new function();
            Hall_manicure.filling();
            Hall_haircup.filling();
            int left_h= 0, left_m=0;
            int day = 0;
            int a=1, b=5;
            int time_now = 480;
            int residue = 0;
             while (day != 7)
            {
                if (day != 6)
                {
                    while (time_now < 721+480)
                    {
                        if (time_now <= 180+480 || time_now >= 540+480)
                        {
                            if (day < 2)
                            {
                                a = 1;
                                b = 5;
                                f.round(Hall_haircup,Hall_manicure,f,ref time_now,ref residue,ref a,ref b,random,cost_man,cost_hair,servis_time_hair,servis_time_man,step,chance_h,chance_m,chance_2,tw);
                            }
                            else
                            {
                                a = 1;
                                b = 9;
                                f.round(Hall_haircup, Hall_manicure, f, ref time_now, ref residue, ref a, ref b, random, cost_man, cost_hair, servis_time_hair, servis_time_man,step, chance_h, chance_m, chance_2,tw);

                            }
                        }
                        else
                        {
                            if (day<2)
                            {
                                a = 1;
                                b = 9;
                                f.round(Hall_haircup, Hall_manicure, f, ref time_now, ref residue, ref a, ref b, random, cost_man, cost_hair, servis_time_hair, servis_time_man,step, chance_h, chance_m, chance_2,tw);

                            }
                            else
                            {
                                a = 1;
                                b = 11;
                                f.round(Hall_haircup, Hall_manicure, f, ref time_now, ref residue, ref a, ref b, random, cost_man, cost_hair, servis_time_hair, servis_time_man,step, chance_h, chance_m, chance_2,tw);

                            }
                        }

                        Console.WriteLine("Количество людей в очереди в зале стрижки:{0} \n",Hall_haircup.queue.Count);
                        Console.WriteLine("Количество людей в очереди в зале маникюра:{0} \n",Hall_manicure.queue.Count);
                        Console.WriteLine("Количество занятых {0} и свободных мастеров {1} в зале маникюра \n", Hall_manicure.unavailable,Hall_manicure.available);
                        Console.WriteLine("Количество занятых {0} и свободных мастеров {1} в зале стрижки \n", Hall_haircup.unavailable,Hall_haircup.available);
                        Console.WriteLine("Количество обслуженных клиентов в зале стрижки: {1}, в зале маникюра: {0} \n",Hall_manicure.count,Hall_haircup.count);
                        Console.WriteLine("Общее количестви времени ожидаения мастеров в зале стрижки: {0} \n",Hall_haircup.average_wairing);
                        Console.WriteLine("Общее количестви времени ожидаения мастеров в зале маникюра: {0} \n",Hall_manicure.average_wairing);
                        Console.WriteLine("Среднее время обслуживания в зале стрижки: {0} \n",Hall_haircup.average_service/Hall_haircup.N);
                        Console.WriteLine("Среднее время обслуживания в зале маникюра: {0} \n",Hall_manicure.average_service/Hall_manicure.N);
                        tw.WriteLine("Количество людей в очереди в зале стрижки:{0} \n", Hall_haircup.queue.Count);
                        tw.WriteLine("Количество людей в очереди в зале маникюра:{0} \n", Hall_manicure.queue.Count);
                        tw.WriteLine("Количество занятых {0} и свободных мастеров {1} в зале маникюра \n", Hall_manicure.unavailable, Hall_manicure.available);
                        tw.WriteLine("Количество занятых {0} и свободных мастеров {1} в зале стрижки \n", Hall_haircup.unavailable, Hall_haircup.available);
                        tw.WriteLine("Количество обслуженных клиентов в зале стрижки: {1}, в зале маникюра: {0} \n", Hall_manicure.count, Hall_haircup.count);
                        tw.WriteLine("Общее количестви времени ожидаения мастеров в зале стрижки: {0} \n", Hall_haircup.average_wairing);
                        tw.WriteLine("Общее количестви времени ожидаения мастеров в зале маникюра: {0} \n", Hall_manicure.average_wairing);
                        tw.WriteLine("Среднее время обслуживания в зале стрижки: {0} \n", Hall_haircup.average_service / Hall_haircup.N);
                        tw.WriteLine("Среднее время обслуживания в зале маникюра: {0} \n", Hall_manicure.average_service / Hall_manicure.N);
                        time_now += step;
                    }
                }
                else
                {
                    while (time_now < 481+480)
                    {
                        if (time_now <= 120+480 || time_now >= 360+480)
                        {
                            a = 1;
                            b = 5;
                            f.round(Hall_haircup, Hall_manicure, f, ref time_now, ref residue, ref a, ref b, random, cost_man, cost_hair, servis_time_hair, servis_time_man,step, chance_h, chance_m, chance_2,tw);

                        }
                        else
                        {
                            a = 1;
                            b = 9;
                            f.round(Hall_haircup, Hall_manicure, f, ref time_now, ref residue, ref a, ref b, random, cost_man, cost_hair, servis_time_hair, servis_time_man, step, chance_h, chance_m, chance_2,tw);

                        }
                        Console.WriteLine("Количество людей в очереди в зале стрижки:{0} \n", Hall_haircup.queue.Count);
                        Console.WriteLine("Количество людей в очереди в зале маникюра:{0} \n", Hall_manicure.queue.Count);
                        Console.WriteLine("Количество занятых {0} и свободных мастеров {1} в зале маникюра \n", Hall_manicure.unavailable, Hall_manicure.available);
                        Console.WriteLine("Количество занятых {0} и свободных мастеров {1} в зале стрижки \n", Hall_haircup.unavailable, Hall_haircup.available);
                        Console.WriteLine("Количество обслуженных клиентов в зале стрижки: {1}, в зале маникюра: {0} \n", Hall_manicure.count, Hall_haircup.count);
                        Console.WriteLine("Общее количестви времени ожидаения мастеров в зале стрижки: {0} \n", Hall_haircup.average_wairing);
                        Console.WriteLine("Общее количестви времени ожидаения мастеров в зале маникюра: {0} \n", Hall_manicure.average_wairing);
                        Console.WriteLine("Среднее время обслуживания в зале стрижки: {0} \n", Hall_haircup.average_service / Hall_haircup.N);
                        Console.WriteLine("Среднее время обслуживания в зале маникюра: {0} \n", Hall_manicure.average_service / Hall_manicure.N);
                        tw.WriteLine("Количество людей в очереди в зале стрижки:{0} \n", Hall_haircup.queue.Count);
                        tw.WriteLine("Количество людей в очереди в зале маникюра:{0} \n", Hall_manicure.queue.Count);
                        tw.WriteLine("Количество занятых {0} и свободных мастеров {1} в зале маникюра \n", Hall_manicure.unavailable, Hall_manicure.available);
                        tw.WriteLine("Количество занятых {0} и свободных мастеров {1} в зале стрижки \n", Hall_haircup.unavailable, Hall_haircup.available);
                        tw.WriteLine("Количество обслуженных клиентов в зале стрижки: {1}, в зале маникюра: {0} \n", Hall_manicure.count, Hall_haircup.count);
                        tw.WriteLine("Общее количестви времени ожидаения мастеров в зале стрижки: {0} \n", Hall_haircup.average_wairing);
                        tw.WriteLine("Общее количестви времени ожидаения мастеров в зале маникюра: {0} \n", Hall_manicure.average_wairing);
                        tw.WriteLine("Среднее время обслуживания в зале стрижки: {0} \n", Hall_haircup.average_service / Hall_haircup.N);
                        tw.WriteLine("Среднее время обслуживания в зале маникюра: {0} \n", Hall_manicure.average_service / Hall_manicure.N);
                        time_now += step;
                    }
                }
                time_now = 480;
                day += 1;
                left_h += Hall_haircup.left;
                left_m += Hall_manicure.left;
                f.clear(Hall_haircup);
                f.clear(Hall_manicure);
            }

            f.salary(Hall_manicure, Hall_haircup);
            Console.WriteLine("Среднее заработная плата мастера в зале маникюра: {0} \n", Hall_manicure.average_salary);
            Console.WriteLine("Среднее  заработная плата мастера в зале стрижке: {0} \n", Hall_haircup.average_salary);
            Console.WriteLine("кол-во мастеров, в зале стрижки: {0}\nкол-во мастеров, в зале маникюра: {1}\nшаг иметации: {2}\nвероятность выбора стрижки: {3}\nвероятность выбора маникюра: {4}\nвероятность выбора 2 услуг: {5}\nстоимость стрижки: {6}\nстоимость маникюра: {7}\nвремя ослуживания в зале стрижки: {8}\nвремя ослуживания в зале маникюра: {9}\n",
                number_2,number_1,step,chance_h,chance_m,chance_2,cost_hair,cost_man,servis_time_hair,servis_time_man);
            tw.WriteLine("Среднее заработная плата мастера в зале маникюра: {0} \n", Hall_manicure.average_salary);
            tw.WriteLine("Среднее  заработная плата мастера в зале стрижке: {0} \n", Hall_haircup.average_salary);
            tw.WriteLine("кол-во мастеров, в зале стрижки: {0}\nкол-во мастеров, в зале маникюра: {1}\nшаг иметации: {2}\nвероятность выбора стрижки: {3}\nвероятность выбора маникюра: {4}\nвероятность выбора 2 услуг: {5}\nстоимость стрижки: {6}\nстоимость маникюра: {7}\nвремя ослуживания в зале стрижки: {8}\nвремя ослуживания в зале маникюра: {9}\n",
                number_2,number_1,step,chance_h,chance_m,chance_2,cost_hair,cost_man,servis_time_hair,servis_time_man);
            tw.Close();
        }
    }
}