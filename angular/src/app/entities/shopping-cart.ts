export interface ShoppingCartRequest {
    id: number;
    quantity: number;
}

export interface ShoppingCartList {
    id: number;
    name: string;
    quantity: number;
    price: number;
    totalPrice: number;
    promotionName: string;
}
