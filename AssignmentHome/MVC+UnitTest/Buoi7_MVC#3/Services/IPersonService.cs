using Buoi6_MVC_3.Models;

namespace Buoi6_MVC_3.Services
{
    public interface IPersonService 
    {
        List<PersonModel> GetAll();

        PersonModel? GetOne(int index);

        PersonModel Create(PersonModel model);

        PersonModel? Update(int index, PersonModel model);

        PersonModel? Delete(int index);

    }
}