namespace WumpusGame
{
    public interface ITrap
    {
        Result getShot();
        void presentSign();
        Result getIn(Warrior warrior);
    }
}