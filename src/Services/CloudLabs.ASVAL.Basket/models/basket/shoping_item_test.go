package basket_test

import (
	"testing"

	"github.com/CloudLabs.ASVAL.Basket/models/basket"
	"github.com/google/uuid"
	"github.com/stretchr/testify/assert"
	"github.com/stretchr/testify/require"
)

//Example test for Basket Item
func TestCreatingNewBasketItem(t *testing.T) {
	itemuuid := uuid.New().String()
	productId := "123456"
	productName := "Chris Chips"
	price := 8
	oldPrice := 5
	quantity := 10

	newBasketItem, errors := basket.NewShoppingItem(itemuuid, productId, productName, price, oldPrice, quantity)

	require.NoError(t, errors)

	assert.Equal(t, itemuuid, newBasketItem.UUID)
}
