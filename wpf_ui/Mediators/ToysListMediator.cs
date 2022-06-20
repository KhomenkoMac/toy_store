using BuisnessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace wpf_ui.Mediators
{
    public class ToysListMediator
    {
        private readonly TheStore _theStore;
        private readonly Lazy<Task> _initializeLazy;
        private readonly CartMediator _cartMediator;

        private ICollection<Toy> _toys = new List<Toy>();
        public ICollection<Toy> Toys => _toys;

        public ToysListMediator(TheStore theStore, CartMediator cartMediator)
        {
            _theStore = theStore;
            _cartMediator = cartMediator;
            _initializeLazy = new Lazy<Task>(InitToys);
        }

        public async Task Load()
        {
            await _initializeLazy.Value;
        }

        private async Task InitToys()
        {
            _toys.Clear();
            var fromBase = await _theStore.GetAllToys();
            fromBase.ToList().ForEach(obj => _toys.Add(obj));
        }

        public async Task Add(Toy toy)
        {
            var addedToy = await _theStore.AddToStore(toy);
            _toys.Add(addedToy);
        }

        public async Task Update(Toy toy)
        {
            await _theStore.Update(toy);
            int index = _toys.ToList().FindIndex(obj => obj.Id == toy.Id);
            var list = _toys.ToList();
            list[index] = toy;
            _toys = list;
        }
        public async Task Delete(Toy toy)
        {
            await _theStore.DeleteFromStore(toy.Id);
            var found = _toys.FirstOrDefault(obj => obj.Id == toy.Id);
            _toys.Remove(found);
        }
    }
}
