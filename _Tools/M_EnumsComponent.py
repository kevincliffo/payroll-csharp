#Enums Container

class EnumsForRecordTasks(object):
    def __init__(self):
        self._First = 0
        self._Next = 1
        self._Previous = 2
        self._Last = 3
    
    def _getFirst(self):
        return self._First

    def _getNext(self):
        return self._Next
            
    def _getPrevious(self):
        return self._Previous
            
    def _getLast(self):
        return self._Last				

    efrmFirst = property(_getFirst)
    efrmNext = property(_getNext)
    efrmPrevious = property(_getPrevious)
    efrmLast = property(_getLast)

class EnumsForDatabaseTasks(object):
    def __init__(self):
        self._Add = 0
        self._Remove = 1

    def _getAdd(self):
        return self._Previous
            
    def _getRemove(self):
        return self._Last				

    efdbtAdd = property(_getAdd)
    efdbtRemove = property(_getRemove)

class EnumsValueType(object):
    def __init__(self):
        self._String = 0
        self._Integer = 1
        self._Long = 2
        self._Double = 3
        self._Boolean = 4

    def _getString(self):
        return self._String

    def _getInteger(self):
        return self._Integer

    def _getLong (self):
        return self._Long    

    def _getDouble(self):
        return self._Double

    def _getBoolean(self):
        return self._Boolean

    efavString = property(_getString)
    efavInteger = property(_getInteger)
    efavLong = property(_getLong)
    efavDouble = property(_getDouble)
    efavBoolean = property(_getBoolean)

class EnumsForStatus(object):
    def __init__(self):
        self._NotStarted = 0
        self._Started = 1
        self._Finished = 2
        self._Paused = 3

    def _getNotStarted(self):
        return self._NotStarted

    def _getStarted (self):
        return self._Started    

    def _getFinished(self):
        return self._Finished

    def _getPaused(self):
        return self._Paused

    efsNotStarted = property(_getNotStarted)
    efsStarted = property(_getStarted)
    efsFinished = property(_getFinished)
    efsPaused= property(_getPaused)

class EnumsRecordFindType(object):
    def __init__(self):
        self._EqualTo = 0
        self._LessThan = 1
        self._GreaterThan = 2
        self._NotEqualTo = 3
        self._LessThanOrEqualTo = 4
        self._GreaterThanOrEqualTo = 5

    def _getEqualTo(self):
        return self._EqualTo

    def _getLessThan(self):
        return self._LessThan

    def _getGreaterThan(self):
        return self._GreaterThan

    def _getNotEqualTo(self):
        return self._NotEqualTo

    def _getLessThanOrEqualTo(self):
        return self._LessThanOrEqualTo

    def _getGreaterThanOrEqualTo(self):
        return self._GreaterThanOrEqualTo

    erftcEqualTo = property(_getEqualTo)
    erftcLessThan= property(_getLessThan)
    erftcGreaterThan = property(_getGreaterThan)
    erftcNotEqualTo = property(_getNotEqualTo)
    erftcLessThanOrEqualTo = property(_getLessThanOrEqualTo)
    erftcGreaterThanOrEqualTo = property(_getGreaterThanOrEqualTo)
    
class EnumMessageType(object):
    def __init__(self):
        self._Success = 0
        self._Information = 1
        self._Error = 2
        self._Prompt = 3
        
    def _getSuccess(self):
        return self._Success

    def _getInformation(self):
        return self._Information

    def _getError(self):
        return self._Error

    def _getPrompt(self):
        return self._Prompt
           
    emtSuccess = property(_getSuccess)
    emtInformation = property(_getInformation)
    emtError = property(_getError)
    emtPrompt = property(_getPrompt)
    
class EnumControlType(object):
    def __init__(self):
        self._Button = 0
        self._TextBox = 1
        self._Label = 2
        self._Grid = 3
        self._ListBox = 4
        self._RadioButton = 5
        self._CheckBox = 6
        self._ComboBox = 7
        self._StaticBox = 8
        
    def _getButtonEnum(self):
        return self._Button
        
    def _getTextBoxEnum(self):
        return self._TextBox

    def _getLabelEnum(self):
        return self._Label

    def _getGridEnum(self):
        return self._Grid

    def _getListBoxEnum(self):
        return self._ListBox

    def _getRadioButtonEnum(self):
        return self._RadioButton

    def _getCheckBoxEnum(self):
        return self._CheckBox

    def _getComboBoxEnum(self):
        return self._ComboBox

    def _getStaticBoxEnum(self):
        return self._StaticBox
    
    ectButton = property(_getButtonEnum)
    ectTextBox = property(_getTextBoxEnum)
    ectLabel = property(_getLabelEnum)
    ectGrid = property(_getGridEnum)
    ectListBox = property(_getListBoxEnum)
    ectRadioButton = property(_getRadioButtonEnum)
    ectCheckBox = property(_getCheckBoxEnum)
    ectComboBox = property(_getComboBoxEnum)
    ectStaticBox = property(_getStaticBoxEnum)
    
class EnumStudentClass(object):
    def __init__(self):
        self._PreUnit = 0
        self._One = 1
        self._Two = 2
        self._Three = 3
        self._Four = 4
        self._Five = 5
        self._Six = 6
        self._Seven = 7
        self._Eight = 8
        self._All = 9

    def _getPreUnit(self):
        return self._PreUnit
    def _setPreUnit(self, value):
        self._PreUnit = value

    def _getOne(self):
        return self._One
    def _setOne(self, value):
        self._One = value

    def _getTwo(self):
        return self._Two
    def _setTwo(self, value):
        self._Two = value

    def _getThree(self):
        return self._Three
    def _setThree(self, value):
        self._Three = value

    def _getFour(self):
        return self._Four
    def _setFour(self, value):
        self._Four = value
     
    def _getFive(self):
        return self._Five
    def _setFive(self, value):
        self._Five = value

    def _getSix(self):
        return self._Six
    def _setSix(self, value):
        self._Six = value

    def _getSeven(self):
        return self._Seven
    def _setSeven(self, value):
        self._Seven = value

    def _getEight(self):
        return self._Eight
    def _setEight(self, value):
        self._Eight = value

    def _getAll(self):
        return self._All
    def _setAll(self, value):
        self._All = value

    escPreUnit = property(_getPreUnit, _setPreUnit)
    escOne = property(_getOne, _setOne)
    escTwo = property(_getTwo, _setTwo)
    escThree = property(_getThree, _setThree)
    escFour = property(_getFour, _setFour)
    escFive = property(_getFive, _setFive)
    escSix = property(_getSix, _setSix)
    escSeven = property(_getSeven, _setSeven)
    escEight = property(_getEight, _setEight)
    escAll = property(_getAll, _setAll)

class EnumDBFieldType(object):
    def __init__(self):
        self._edbftString = 0
        self._edbftLong = 1
        self._edbftInteger = 2
        self._edbftDouble = 3
        self._edbftDateTime = 4
        self._edbftTime = 5
        self._edbftDate = 6
        
    def _getString(self):
        return self._edbftString

    def _getLong(self):
        return self._edbftLong

    def _getInteger(self):
        return self._edbftInteger

    def _getDouble(self):
        return self._edbftDouble

    def _getDateTime(self):
        return self._edbftDateTime

    def _getTime(self):
        return self._edbftTime

    def _getDate(self):
        return self._edbftDate  

    edbftString = property(_getString)
    edbftLong = property(_getLong)
    edbftInteger = property(_getInteger)
    edbftDouble = property(_getDouble)
    edbftDateTime = property(_getDateTime)
    edbftTime = property(_getTime)
    edbftDate = property(_getDate)

class EnumSQLQueryType(object):
    def __init__(self):
        self._esqlqtSelect = 0
        self._esqlqtInsert = 1
        self._esqlqtUpdate = 2
        self._esqlqtDelete = 3    

    def _getSelect(self):
        return self._esqlqtSelect

    def _getInsert(self):
        return self._esqlqtInsert

    def _getUpdate(self):
        return self._esqlqtUpdate

    def _getDelete(self):
        return self._esqlqtDelete

    esqlqtSelect = property(_getSelect)
    esqlqtInsert = property(_getInsert)
    esqlqtUpdate = property(_getUpdate)
    esqlqtDelete = property(_getDelete)
    
if __name__ == '__main__':
    ect = EnumControlType()
    print ect.ectButton
    print ect.ectTextBox
    print ect.ectLabel
    print ect.ectGrid
    print ect.ectListBox
    print ect.ectRadioButton
    print ect.ectCheckBox
