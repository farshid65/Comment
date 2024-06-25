using CooKFoodDB.Foods;
using Core.Domain.Foods;
using Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService
{
    public class FoodsApplicationService : IApplicationService
    {
        private readonly IFoodRepository _repository;
        private readonly IUnitofwork _unitofwork;
        

        public FoodsApplicationService(IFoodRepository repository, IUnitofwork unitofwork)
        {
            _repository = repository;
            _unitofwork = unitofwork;
        }
        public Task Handle(object command)
        => command switch
        {
            Foods.V1.Create cmd => HandleCreate(cmd),
            


        };

        private async Task HandleCreate(Foods.V1.Create cmd)
        {
            if (await _repository.ExistAsync(cmd.Id))
                throw new InvalidOperationException(
                    $"Entity with id {cmd.Id} already exists");
            await _repository.Add(entity);
            await _unitofwork.Commit();
        }

        private async Task HandleUpdate(int foodId, Action<Food> operation)
        {
            var food = await
                _repository.LoadAsync(foodId);
            if (food == null)
                throw new InvalidOperationException(
                    $"Entity with id {foodId} can not be found");
            operation(food);
            await _unitofwork.Commit();

        }
    }
}
