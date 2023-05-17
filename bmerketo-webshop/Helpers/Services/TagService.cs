using bmerketo_webshop.Models.Entities;
using bmerketo_webshop.Models;
using System.Linq.Expressions;
using bmerketo_webshop.Helpers.Repositories;

namespace bmerketo_webshop.Helpers.Services;

public class TagService
{
    private readonly TagRepo _tagRepo;

    public TagService(TagRepo tagRepo)
    {
        _tagRepo = tagRepo;
    }

    // create


    // get
    public async Task<TagModel?> GetAsync(Expression<Func<TagEntity, bool>> predicate)
    {
        var entity = await _tagRepo.GetAsync(predicate);

        return entity!;
    }


    // get all
    public async Task<IEnumerable<TagModel>> GetAllAsync()
    {
        var entityList = await _tagRepo.GetAllAsync();
        var models = new List<TagModel>();

        foreach (var entity in entityList)
            models.Add(entity!);

        return models;
    }

    // update

    // delete
}
