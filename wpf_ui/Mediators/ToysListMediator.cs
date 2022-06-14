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
        
        private ICollection<Toy> _toys = new List<Toy>();
        public ICollection<Toy> Toys => _toys;

        public ToysListMediator(TheStore theStore)
        {
            _theStore = theStore;
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
            await _theStore.AddToStore(toy);
            _toys.Add(toy);
        }

    }
}
