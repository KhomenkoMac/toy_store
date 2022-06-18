using BuisnessLogic;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace wpf_ui.Mediators
{
    public class ToyCartMediator 
    {
        private readonly AuthorizationMediator _mediator;
        private readonly TheCart _theCart;
        private readonly Lazy<Task> _initializeLazy;

        private ICollection<Toy> _incartToys = new List<Toy>();
        public ICollection<Toy> Toys => _incartToys;

        public ToyCartMediator(TheCart theCart, AuthorizationMediator mediator)
        {
            _theCart = theCart;
            _initializeLazy = new Lazy<Task>(InitToys);
            _mediator = mediator;
        }

        public async Task Load()
        {
            await _initializeLazy.Value;
        }

        private async Task InitToys()
        {
            throw new NotImplementedException();
            //_incartToys.Clear();
            //var fromBase = await _theCart.GetAllToys();
            //fromBase.ToList().ForEach(obj => _incartToys.Add(obj));
        }

        public async Task Add(Toy toy)
        {
            //await _theCart.AddToStore(toy);
            //_incartToys.Add(toy);
            throw new NotImplementedException();
        }
    }
}
