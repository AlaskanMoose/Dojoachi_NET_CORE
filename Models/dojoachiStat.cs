using System;
namespace dojoachi
{
    public class Dojoachi
    {
        public int Fullness { get; set; }

        public int Happiness { get; set; }

        public int Meals { get; set; }

        public int Energy { get; set; }
        public int gameStatus{ get; set; }
        public string Message { get; set; }
        public Random rand = new Random();
        public Dojoachi()
        {
            Fullness = 20;
            Happiness = 20;
            Meals = 3;
            Energy = 50;
            gameStatus = 1;
            Message="You Created Life!";
        }
        public void feed(){
            int feedValue = rand.Next(5, 11);
            if(Meals > 0){
                Meals -= 1;
                Fullness += feedValue;
                Message = "Your Lebron gained " + feedValue + " Fullness!";
                if(Happiness > 100 && Energy > 100 && Fullness > 100){
                    gameStatus = 2;
                    Message = "You've won, want to play again?";
                }
            }else {
                Message = "You cannot feed your Lebron if you dont have any Meals!";
            }
        }
        public void play(){
            int playValue = rand.Next(5, 11);
            int playChance = rand.Next(1, 5);
            if(Energy >= 5){
                Message = "You've played with Lebron!";
                if(playChance == 1){
                    Message += "Lebron didn't like that!";
                }else{
                    Energy -= 5;
                    Happiness += playValue;
                    Message += "Your Lebron gained " + playValue + " Happiness";
                    if(Happiness > 100 && Energy > 100 && Fullness > 100){
                        gameStatus = 2;
                        Message = "You've won, want to play again?";
                    }
                }

            }else{
                Message = "Lebron is too tired to play";
            }
        }
        public void work(){
            int workChance = rand.Next(1, 4);
            if(Energy >= 5){
                Energy -= 5;
                Meals += workChance;
                Message = "Lebron worked and gained " + workChance + "Meals!";
            }else{
                Message = "Lebron does not have enough Energy to work!";
            }
        }
        public void sleep(){
            Energy += 15;
            Fullness -= 5;
            Happiness -= 5;
            Message = "Lebron slepted and gained 15 energy and lost 5 Fullness and Happiness!";
            if(Fullness < 0 || Happiness < 0){
                gameStatus = 3;
                Message = "Game Over, want to start over?";
            }
            if(Happiness > 100 && Energy > 100 && Fullness > 100){
                gameStatus = 2;
                Message = "You've won, want to play again?";
            }
        }
        public void restart(){
            gameStatus = 1;
        }
    }
}