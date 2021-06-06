using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
namespace ООП_КР_ИМ
{
    class Master
    {
        public Request client;//  Клиент которого в данный момент обслуживают  
        public int service_time;//оставшееся время обслуживания 
        public bool available; //свободен ли мастер 
        public int profit = 0;// заработанные деньги
        public int waiting = 0;// ожидание клиента
        public Master(Request client, int service_time, bool available)
        {
            this.client = client;
            this.service_time = service_time;
            this.available = available;

        }
    }
}
