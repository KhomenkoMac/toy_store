using BuisnessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace wpf_ui.Mediators
{
    public class CartMediator
    {
        private readonly Lazy<Task> _initializeLazy;
        private readonly TheCart _theCart;
        private readonly AuthorizationMediator _authorizationMediator;

        private IDictionary<int, Toy> _inCartToys = new Dictionary<int,Toy>();
        public IDictionary<int, Toy> InCartToys => _inCartToys;

        public CartMediator(
            AuthorizationMediator authorizationMediator, 
            TheCart theCart)
        {
            _authorizationMediator = authorizationMediator;
            _theCart = theCart;
            _initializeLazy = new Lazy<Task>(InitToys);
        }

        public async Task AddToCart(Toy toy)
        {
            await _theCart.AddToCart(_authorizationMediator.CurrentUser, toy);
            _inCartToys.Add(toy.Id, toy);
        }

        public async Task DeleteFromCart(Toy toy)
        {
            await _theCart.DeleteFromCart(_authorizationMediator.CurrentUser, toy);
            _inCartToys.Remove(toy.Id);
        }

        public async Task Load()
        {
            await _initializeLazy.Value;
        }

        private async Task InitToys()
        {
            _inCartToys.Clear();
            var fromBase = await _theCart.GetIncartToys(_authorizationMediator.CurrentUser);
            fromBase.ToList().ForEach(obj => _inCartToys.Add(obj.Id, obj));
        }
    }
}
