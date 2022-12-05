class Program
{
    static void Main()
    {

        string questionText = "What is the capital of USA?";
        string optionA = "London";
        string optionB = "New York";
        string optionC = "Washington D.C.";
        string optionD = "San Diego";
        char correctAnswerText = 'C';

        Question question1 = new Question();

        Question question2 = new Question(questionText);
        Question question3 = new Question(questionText, optionA, optionB, optionC, optionD, correctAnswerText);
        Question question4 = new Question() { questionText = questionText, optionA = optionA, optionB = optionB, optionC = optionC, optionD = optionD };
    }
}