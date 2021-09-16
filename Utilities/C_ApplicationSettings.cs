using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Utilities
{
public class ApplicationSettings
{
    private bool brwxTravelAllowances = false;
    private bool brwxMedicallAllowances = false;
    private bool brwxHouseAllowances = false;

    public bool TravelAllowances
    {
        get
        {
            return brwxTravelAllowances;
        }
        set
        {
            brwxTravelAllowances = value;
        }
    }

    public bool MedicallAllowances
    {
        get
        {
            return brwxMedicallAllowances;
        }
        set
        {
            brwxMedicallAllowances = value;
        }
    }

    public bool HouseAllowances
    {
        get
        {
            return brwxHouseAllowances;
        }
        set
        {
            brwxHouseAllowances = value;
        }
    }
}
}
