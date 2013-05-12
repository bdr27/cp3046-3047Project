using System.Collections.Generic;

namespace NerfWarsPrototype1
{
    public class Game
    {
        private string gameTime;
        private List<string> team1Names;
        private List<string> team2Names;
        private Score team1Score;
        private Score team2Score;

        public Game(string gameTime, List<string> team1Names, List<string> team2Names)
        {
            this.gameTime = gameTime;
            this.team1Names = team1Names;
            this.team2Names = team2Names;
            team1Score = new Score();
            team2Score = new Score();
        }

        public string getGameTime()
        {
            return gameTime;
        }

        public List<string> getPlayer1Names()
        {
            return team1Names;
        }

        public List<string> getPlayer2Names()
        {
            return team2Names;
        }

        public void team1IncreaseTag()
        {
            team1Score.increaseTag();
        }

        public void team1IncreaseCap()
        {
            team1Score.increaseCap();
        }

        public void team2IncreaseTag()
        {
            team2Score.increaseTag();
        }

        public void team2IncreaseCap()
        {
            team2Score.increaseCap();
        }

        public void team1DecreaseTag()
        {
            team1Score.decreaseTag();
        }

        public void team1DecreaseCap()
        {
            team1Score.decreaseCap();
        }

        public void team2DecreaseTag()
        {
            team2Score.decreaseTag();
        }

        public void team2DecreaseCap()
        {
            team2Score.decreaseCap();
        }
    }
}
