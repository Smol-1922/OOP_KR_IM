using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace ООП_КР_ИМ
{
    enum Service
    {
        haircut,
        manicure
    }
    class Request
    {

        public int arrival_time;// время прихода 
        public Service service;//номер услуги
        public bool multiple_services = false;// несколько услуг
        public bool finish = false;// закончил 
        public Request(int arrival_time, Service service)
        {
            this.arrival_time = arrival_time;
            this.service = service;

        }
        public Request()
        {

        }
        public void create(int time, int chance_h, int chance_2,StreamWriter tw)//создание заявки 
        {
            this.arrival_time = time;
            Random random = new Random(Guid.NewGuid().GetHashCode());
            int s = random.Next(0, 101);// вероятность 2 услуги в заявке
            int rnd = random.Next(0, 101);// выбор услуги
            if (rnd >= chance_h)
            {
                this.service = Service.haircut;
                Console.WriteLine("Пришел клиент,услуга-{0} \n", this.service);
                tw.WriteLine("Пришел клиент,услуга-{0} \n", this.service);
            }
            else
            {
                this.service = Service.manicure;
                Console.WriteLine("Пришел клиент,услуга-{0} \n", this.service);
                tw.WriteLine("Пришел клиент,услуга-{0} \n", this.service);

            }
            if (s < chance_2)//вероятность на запись на несколько услуг
            {
                Console.WriteLine("Так же клиент хочет записаться на другую услугу \n", this.service);
                tw.WriteLine("Так же клиент хочет записаться на другую услугу \n", this.service);
                this.multiple_services = true;// несколько услуг 
            }
        }
    }
}
