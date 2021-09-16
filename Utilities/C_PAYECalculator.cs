using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Utilities
{
public class PAYECalculator
{
    public PAYECalculator()
    { 
    
    }

    public void GetTaxDeductionOverGrossSalary(double dvSalary,
                                               ref double drTaxDeduction)
    {
                                        double dTaxCharged = 0;
                                        double dTaxablePay = 0;

        while (true)
        {
            if(dvSalary < 1)
            {
                break;
            }

            if ((dvSalary >= 10164.0))
            {
                dTaxablePay = 10164.0;
                dTaxCharged = dTaxCharged
                            + (0.1 * dTaxablePay);
                dTaxCharged = Math.Round(dTaxCharged, 2);

            }

            if ((dvSalary >=  19740.0))
            {
                dTaxablePay = 19740.0 - 10164.0;
                dTaxCharged = dTaxCharged 
                            + (0.15 * dTaxablePay);
                dTaxCharged = Math.Round(dTaxCharged, 2);
            }

            if ((dvSalary >= 29316.0))
            {
                dTaxablePay = 29316.0 - 19740.0;
                dTaxCharged = dTaxCharged
                            + (0.2 * dTaxablePay);
                dTaxCharged = Math.Round(dTaxCharged, 2);
            }

            if ((dvSalary >= 38892.0))
            {
                dTaxablePay = 38892.0 - 29316.0;
                dTaxCharged = dTaxCharged
                            + (0.25 * dTaxablePay);
                dTaxCharged = Math.Round(dTaxCharged, 2);
            }

            if (dvSalary > 38893.0)
            {
                dTaxablePay = dvSalary - 38892.0;
                dTaxCharged = dTaxCharged
                            + (0.3 * dTaxablePay);
                dTaxCharged = Math.Round(dTaxCharged, 2);
            }

            break;
        }

        drTaxDeduction = dTaxCharged;
    }
}
}
