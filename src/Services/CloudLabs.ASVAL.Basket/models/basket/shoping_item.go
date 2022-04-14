package basket

import "errors"

type ShoppingItem struct {
	UUID        string
	ProductId   string
	ProductName string
	Price       int
	OldPrice    int
	Quantity    int
}

func NewShoppingItem(uuid string, productId string, productName string, price int, oldPrice int, quantity int) (*ShoppingItem, error) {
	if uuid == "" {
		return nil, errors.New("empty basket item uuid")
	}
	if productId == "" {
		return nil, errors.New("empty product id")
	}
	if productName == "" {
		return nil, errors.New("empty product name")
	}
	if price == 0 || price < 0 {
		return nil, errors.New("price cannot be equal or less than zero")
	}
	if oldPrice == 0 || oldPrice < 0 {
		return nil, errors.New("old price cannot be equal or less than zero")
	}
	if quantity == 0 || quantity < 0 {
		return nil, errors.New("quantity requires at least one item")
	}
	return &ShoppingItem{
		UUID:        uuid,
		ProductId:   productId,
		ProductName: productName,
		Price:       price,
		OldPrice:    oldPrice,
		Quantity:    quantity,
	}, nil
}
