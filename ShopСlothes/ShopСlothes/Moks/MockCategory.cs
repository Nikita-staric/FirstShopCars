using ShopСlothes.Interface;
using ShopСlothes.Models;

namespace ShopСlothes.Moks
{
    public class MockCategory : ICarsCategory
    {
        public IEnumerable<Category> AllCategory { 
            get {//какие категоии будут возращаться 
                return new List<Category> { 
                    new Category { Categoryy = "ЭлектроМобиль" , Description ="пушка Ракета"},
                    new Category { Categoryy = "Класические машинны" ,Description="Хуита"} };
                }
        }
    }
}
