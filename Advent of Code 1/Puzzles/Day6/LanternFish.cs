using System;
using System.Collections.Generic;
using System.Text;


public class LanternFish
{
    public int daysLeft = 8;
    public bool readyForOffspring => daysLeft <= 0;
    public LanternFish(int daysLeft)
    {
        this.daysLeft = daysLeft;
    }

    public LanternFish CreateOffspring()
    {
        return new LanternFish(8);
    }

}