using BLL.DTOs;
using DAL.Entities;
using DAL.Repositories;

namespace BLL.Services;

public class CartItemService
{
    private readonly CartItemRepository _cartItemRepository = new();

    public async Task<List<CartItem>> GetAllAsync() => await _cartItemRepository.GetAllAsync();

    public async Task<CartItem?> GetByIdAsync(int id) => await _cartItemRepository.GetByIdAsync(id);

    public async Task AddAsync(CartItem cartItem)
    {
        await _cartItemRepository.AddAsync(cartItem);
        await _cartItemRepository.SaveChangesAsync();
    }

    public async Task UpdateAsync(CartItem cartItem)
    {
        _cartItemRepository.Update(cartItem);
        await _cartItemRepository.SaveChangesAsync();
    }

    public async Task DeleteAsync(CartItem cartItem)
    {
        _cartItemRepository.Remove(cartItem);
        await _cartItemRepository.SaveChangesAsync();
    }
    public async Task<List<CartItemDto>> GetCartItemDtosByUserIdAsync(int userId)
    {
        var cartItems = await _cartItemRepository.GetAllCartItemWithProductAsync();

        var filtered = cartItems
            .Where(ci => ci.UserId == userId && ci.Product != null)
            .Select(ci => new CartItemDto
            {
                CartItemId = ci.CartItemId,
                UserId = ci.UserId,
                ProductId = ci.ProductId,
                Quantity = ci.Quantity,
                Name = ci.Product!.Name,
                ImageUrl = ci.Product.ImageUrl,
                Price = ci.Product.Price
            })
            .ToList();

        return filtered;
    }


    public async Task<bool> ExistsByProductIdAsync(int productId)
            => await _cartItemRepository.ExistsByProductIdAsync(productId);


}
