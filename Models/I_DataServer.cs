using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CollectionClasses;
using DataBaseManagement;

namespace Models
{
    interface I_DataServer
    {
        void FindRecordOverFieldValues(ref Fields fdsr,
                                       ref bool brErrorFound,
                                       ref bool brNothingFound,
                                       ref string szrErrorMessage);

        void AddToDataBase(Fields fdsv,
                           ref bool brErrorFound,
                           ref string szrErrorMessage);

        void RemoveFromDataBase(Fields fdsv,
                                ref bool brErrorFound,
                                ref string szrErrorMessage);

        void GetNextHighestId(ref long lrId);

        void GetPreviousRecordFromDataBase(ref Fields fdsr,
                                           ref bool brEndOfFind,
                                           ref bool brErrorFound,
                                           ref string szrErrorMessage);

        void GetNextRecordFromDataBase(ref Fields fdsr,
                                       ref bool brEndOfFind,
                                       ref bool brErrorFound,
                                       ref string szrErrorMessage);

        void GetLastRecordFromDataBase(ref Fields fdsr,
                                       ref bool brNothingFound,
                                       ref bool brErrorFound,
                                       ref string szrErrorMessage);

        void GetFirstRecordFromDataBase(ref Fields fdsr,
                                        ref bool brNothingFound,
                                        ref bool brErrorFound,
                                        ref string szrErrorMessage);
        Fields Fields
        {
            get;
        }
    }
}
