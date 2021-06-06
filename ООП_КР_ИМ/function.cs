using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
namespace ООП_КР_ИМ
{     class function
    {
       public function() { }
        public void fan(Hall hall,Hall hall_add,int rnd,int cost, int servis_time,StreamWriter tw) {//проверка на то что мастер закончил обслуживать клиента
            for (int i = 0; i < hall.masters.Count; i++)
            {
                if (!hall.masters[i].available)// свободен ли мастер
                {
                    hall.masters[i].service_time -= rnd;// уменьшает время оставшееся до конца обслуживания 
                    if (hall.masters[i].service_time < 0)// если время вышло
                    {
                        Console.WriteLine("Мастер закончил работу с клиентом \n");
                        tw.WriteLine("Мастер закончил работу с клиентом \n");
                        if (hall.masters[i].client.multiple_services)// есть ли у клиента еще услуги
                        {
                            for(int j = 0; j < hall_add.queue.Count; j++)
                            {
                                if (hall_add.queue[j].multiple_services&&!hall_add.queue[j].finish)
                                {
                                    hall_add.queue[j].finish = true;
                                    break;
                                }
                            }

                        }
                        if (hall.queue.Count == 0)// если очереди нет 
                        {
                            Console.WriteLine("У мастера нет новых клиентов \n");
                            tw.WriteLine("У мастера нет новых клиентов \n");
                            hall.masters[i].client = null;
                            hall.masters[i].available = true;
                            hall.available++;
                            hall.unavailable--;
                        }
                        else
                        {
                            bool flag = true;
                            hall.count++;
                            for (int j = 0; j < hall.queue.Count; j++)
                            {
                                if (hall.queue[j].finish)
                                {
                                    Console.WriteLine("Клиент котоорый записался на 2 услуги под номером {0} в очереди обслуживается мастером, размер очереди уменьшилось \n", j+1);
                                    tw.WriteLine("Клиент котоорый записался на 2 услуги под номером {0} в очереди обслуживается мастером, размер очереди уменьшилось \n", j+1);
                                    hall.masters[i].client = hall.queue[j];
                                    hall.queue.RemoveAt(j);
                                    flag = false;
                                    break;
                                }
                            }
                            if (flag)
                            {
                                for (int j = 0; j < hall.queue.Count; j++)
                                {
                                    if (!hall.queue[j].multiple_services)
                                    {
                                        Console.WriteLine("Клиент под номером {0} обслуживается мастером, размер очереди уменьшилось \n", j+1);
                                        tw.WriteLine("Клиент под номером {0} обслуживается мастером, размер очереди уменьшилось \n", j+1);
                                        hall.masters[i].client = hall.queue[j];
                                        hall.queue.RemoveAt(j);
                                        flag = false;
                                        break;

                                    }
                                }
                            }
                            if (flag)
                            {
                                Console.WriteLine("У мастера нет новых клиентов \n");
                                tw.WriteLine("У мастера нет новых клиентов \n");
                                hall.masters[i].client = null;
                                hall.masters[i].available = true;
                                hall.available++;
                                hall.unavailable--;
                            }
                            else
                            {
                                hall.masters[i].profit += cost;
                                Console.WriteLine("Выручка на данный момент составляет {0}\n", hall.masters[i].profit);
                                Console.WriteLine("Выручка мастера на данный момент составляет {0}\n",( hall.masters[i].profit/100)*40);  
                                tw.WriteLine("Выручка на данный момент составляет {0}\n", hall.masters[i].profit);
                                tw.WriteLine("Выручка мастера на данный момент составляет {0}\n",( hall.masters[i].profit/100)*40);
                                Random random1 = new Random(Guid.NewGuid().GetHashCode());
                                hall.masters[i].service_time = servis_time + random1.Next(5, 31);
                                hall.average_service += hall.masters[i].service_time;
                                hall.N++;
                                hall.overflow = false;
                            }
                        }
                    }
                }
                else
                {
                    hall.masters[i].waiting += rnd;// если мастер занят увеличиваает значение его времени ожидания
                }
            }
        }
        public void fff(Hall hall,Hall hall_add,Request request,int cost, int servis_time,StreamWriter tw)// выдача клиента мастеру 
        {
            if (hall.available != 0)
            {
                Console.WriteLine("Есть свободные мастера \n");
                tw.WriteLine("Есть свободные мастера \n");
                for (int i = 0; i < hall.masters.Count; i++)
                    if (hall.masters[i].available)
                    {
                        hall.masters[i].client = request;
                        hall.masters[i].available = false;
                        Random random1 = new Random(Guid.NewGuid().GetHashCode());
                        hall.masters[i].service_time = servis_time + random1.Next(5, 31);
                        hall.N++;
                        hall.average_wairing += hall.masters[i].waiting;
                        hall.average_service += hall.masters[i].service_time;
                        hall.masters[i].profit+=cost;
                        hall.masters[i].waiting = 0;
                        hall.available--;
                        hall.unavailable++;
                        hall.count++;
                        if (request.multiple_services&&hall_add.queue.Count<5)
                        {
                            Console.WriteLine("Так же клиент был записан в очередь в другой зал под номером {0}\n", hall_add.queue.Count+1);
                            tw.WriteLine("Так же клиент был записан в очередь в другой зал под номером {0}\n", hall_add.queue.Count+1);
                            hall_add.queue.Add(request);
                        }
                        break;
                    }
            }
            else
            {
                Console.WriteLine("Нет свободных мастеров \n");
                tw.WriteLine("Нет свободных мастеров \n");
                if (hall.queue.Count != 5)
                {
                    Console.WriteLine("Есть свободное место в очереди,клиент находится в очереди под номером {0}\n", hall.queue.Count+1);
                    tw.WriteLine("Есть свободное место в очереди,клиент находится в очереди под номером {0}\n", hall.queue.Count+1);
                    if (request.multiple_services && hall_add.queue.Count < 5)
                    {
                        Console.WriteLine("Так же клиент был записан в очередь в другой зал под номером {0}\n", hall_add.queue.Count+1);
                        tw.WriteLine("Так же клиент был записан в очередь в другой зал под номером {0}\n", hall_add.queue.Count+1);
                        hall_add.queue.Add(request);
                    }
                    hall.queue.Add(request);
                }
                else
                {
                    Console.WriteLine("Нет свободных мест в очереди \n");
                    Console.WriteLine("Клиент ушел\n");
                    tw.WriteLine("Нет свободных мест в очереди \n");
                    tw.WriteLine("Клиент ушел\n");
                    hall.overflow = true;
                }
            }
        }
        public void clear(Hall hall)// очищает зал в конце дня
        {
            for (int i = 0; i < hall.masters.Count; i++)
            {
                hall.masters[i].client = null;
                hall.masters[i].available = true;
                hall.masters[i].service_time = 0;
                hall.masters[i].waiting= 0;
            }
            hall.overflow = false;
            hall.available = hall.quantity;
            hall.unavailable = 0;
            hall.left = 0;
            hall.queue.Clear();
        }
        public void round(Hall Hall_haircup,Hall Hall_manicure,function f,ref int time_now,ref int residue,ref int a,ref int b,Random random,int cost_man,int cost_hair,int servis_time_hair,int servis_time_man,int step,int chans_h,int chans_m,int chance_2,StreamWriter tw)// включает в себя код повторяющийся несколько раз поэтому была создана функция дабы уменьшить размер кода 
        {
            int time = step;
            while (time != 0)
            {
                
                Console.WriteLine("___________________________________________________________________________________________________________________\n");
                tw.WriteLine("___________________________________________________________________________________________________________________\n");
                Console.WriteLine("Время: {0}:{1}\n",(time_now+30-time)/60, (time_now + 30 - time)%60);
                tw.WriteLine("Время: {0}:{1}\n",(time_now+30-time)/60, (time_now + 30 - time)%60);
                Random random_1 = new Random(Guid.NewGuid().GetHashCode());
                int persents = random_1.Next(0, 100);
                if (Hall_haircup.left + Hall_manicure.left < persents)
                {
                    if (residue != 0)
                    {
                        time -= residue;
                        residue = 0;
                    }
                    Request reques = new Request();
                    reques.create(time_now,chans_h, chance_2,tw);
                    if (Hall_haircup.specialization == reques.service)
                    {
                        f.fff(Hall_haircup, Hall_manicure, reques, cost_hair, servis_time_hair,tw);
                        if (Hall_haircup.overflow)
                        {
                            Hall_haircup.left++;
                            Console.WriteLine("Вероятность прихода нового клиента уменьшилась, теперь она составляет: {0}%\n", 100 - (Hall_haircup.left + Hall_manicure.left));
                            tw.WriteLine("Вероятность прихода нового клиента уменьшилась, теперь она составляет: {0}%\n", 100 - (Hall_haircup.left + Hall_manicure.left));
                        }

                    }
                    else
                    {
                        f.fff(Hall_manicure, Hall_haircup, reques, cost_man, servis_time_man, tw);
                        if (Hall_manicure.overflow)
                        {
                            Hall_manicure.left++;
                            Console.WriteLine("Вероятность прихода нового клиента уменьшилась, теперь она составляет: {0}%\n", 100 - (Hall_haircup.left + Hall_manicure.left));
                            tw.WriteLine("Вероятность прихода нового клиента уменьшилась, теперь она составляет: {0}%\n", 100 - (Hall_haircup.left + Hall_manicure.left));
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Клиент не пришел");
                    tw.WriteLine("Клиент не пришел");
                }
                    int rnd = random.Next(a, b);

                    f.fan(Hall_haircup, Hall_manicure, rnd, cost_hair, servis_time_hair, tw);
                    f.fan(Hall_manicure, Hall_haircup, rnd, cost_man, servis_time_man, tw);
                    if (time > rnd)
                        time -= rnd;
                    else
                    {
                        time = rnd - time;
                        residue = time;
                        time = 0;
                    }
                Console.WriteLine("___________________________________________________________________________________________________________________\n");
                tw.WriteLine("___________________________________________________________________________________________________________________\n");
            }
        }
        public void salary(Hall hall_m,Hall hall_h)// посчет средней заработной платы мастеров и выручки каждого зала 
        {
            for (int i = 0; i < hall_h.quantity; i++) {
                if (hall_h.masters[i].profit / 100 * 40 > 7000)
                {
                    hall_h.salary += hall_h.masters[i].profit - hall_h.masters[i].profit / 100 * 40;
                    hall_h.masters[i].profit = hall_h.masters[i].profit / 100 * 40;
                }
                else
                {
                    hall_h.salary += hall_h.masters[i].profit - 7000;
                    hall_h.masters[i].profit = 7000;
                }
                hall_h.average_salary += hall_h.masters[i].profit;
            }
            hall_h.average_salary /= hall_h.quantity;
            for (int i = 0; i < hall_m.quantity; i++) {
                if (hall_m.masters[i].profit / 100 * 40 > 7000)
                {
                    hall_m.salary += hall_m.masters[i].profit - hall_m.masters[i].profit / 100 * 40;
                    hall_m.masters[i].profit = hall_m.masters[i].profit / 100 * 40;
                }
                else
                {
                    hall_m.salary += hall_m.masters[i].profit -7000;
                    hall_m.masters[i].profit = 7000;
                }
                hall_m.average_salary += hall_m.masters[i].profit;
            }
            hall_m.average_salary /= hall_m.quantity;
        }
    }
}