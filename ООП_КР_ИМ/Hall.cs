using System;
using System.Collections.Generic;
using System.Text;

namespace ООП_КР_ИМ
{
    class Hall
    {
        public int quantity;// Кол-во мастеров 
        public int salary = 0;// Заработок мастеров в зале
        public int average_salary = 0;// Кол-во мастеров 
        public int available;//доступно мастеров
        public int unavailable;//недоступно мастеров
        public List<Request> queue;//очередь максимум 5
        public Service specialization;//специализация зала
        public List<Master> masters;//список мастеров
        public int count = 0;// кол-во клиентов 
        public bool overflow = false;// переполнение очереди 
        public int left = 0;//кол-во непринятых заявок 
        public int average_wairing = 0;// общее время ожидания
        public int average_service = 0, N = 0;// среднее время оказания услуги
        public Hall(int quantity, int available, int unavailable, List<Request> queue, Service specialization, List<Master> masters)
        {
            this.quantity = quantity;
            this.available = available;
            this.unavailable = unavailable;
            this.queue = queue;
            this.specialization = specialization;
            this.masters = masters;
        }
        public void filling()//заполняет список мастеров 
        {
            int i = 0;
            while (this.quantity != i)
            {
                Master m = new Master(null, 0, true);
                this.masters.Add(m);
                i++;
            }
        }
    }
}
