namespace TermProject;

public interface IBattle
{
    CardBack GetBack();
    int GetDefense();
    void SetBack(CardBack back);
    void SetDefense(int defense);
}