public class Question
{
    public string questionText;
    public string optionA;
    public string optionB;
    public string optionC;
    public string optionD;
    public char correctAnswerLetter;
    private static char defaultCorrectAnswerLetter = 'X';

    public Question()
    {
        questionText = null;
        optionA = null;
        optionB = null;
        optionC = null;
        optionD = null;

        correctAnswerLetter = Question.defaultCorrectAnswerLetter;
    }

    public Question(string questionText)
    {
        this.questionText = questionText;
        correctAnswerLetter = defaultCorrectAnswerLetter;
    }

    public Question(string questionText, string optionA, string optionB, string optionC, string optionD, char correctAnswerLetter)
    {
        this.questionText = questionText;
        this.optionA = optionA;
        this.optionB = optionB;
        this.optionC = optionC;
        this.optionD = optionD;
        if (correctAnswerLetter == 'A' || correctAnswerLetter == 'B' || correctAnswerLetter == 'C' || correctAnswerLetter == 'D')
            this.correctAnswerLetter = correctAnswerLetter;
        else
            this.correctAnswerLetter = Question.defaultCorrectAnswerLetter;
       
    }

    public bool CheckQuestionOptions()
    {
        int validOptionsNumber = 0;
        if (this.optionA != null)
        {
            validOptionsNumber++;
        }
        if (this.optionB != null)
        {
            validOptionsNumber++;
        }
        if (this.optionC != null)
        {
            validOptionsNumber++;
        }
        if (this.optionD != null)
        {
            validOptionsNumber++;
        }

        return validOptionsNumber >= 2;
    }
}