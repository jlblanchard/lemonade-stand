import lemonade from "../types/lemonade";
import order from "../types/order";

export class LemonadeService {

    public async getLemonades(): Promise<lemonade[]> {
        const response = await fetch('https://localhost:7284/api/lemonade');
        return await response.json();
    }

    public async submitOrder(order: order): Promise<number> {
        const response = await fetch('https://localhost:7284/api/order',{
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(order)
        });

        return await response.json();
    }
}