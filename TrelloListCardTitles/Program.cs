using Manatee.Trello;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrelloListCardTitles
{
    class Program
    {
        static void Main(string[] args)
        {
            Task task = ReadData();
            task.Wait();
        }

        private static async Task ReadData()
        {
            try
            {
                TrelloAuthorization.Default.AppKey = "";
                TrelloAuthorization.Default.UserToken = "";

                ITrelloFactory factory = new TrelloFactory();
                var board = factory.Board("nC8QJJoZ");
                
                await board.Refresh();
                var cards = board.Cards;
                await cards.Refresh();

                foreach (Card card in cards)
                    Console.WriteLine(card.Name);

                Console.ReadLine();

            }catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
