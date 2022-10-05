import React, { useState } from 'react';
import lemonade from '../types/lemonade';
import OrderTable from './ordertable';
import order from '../types/order';
import OrderSubmit from './ordersubmit';
import { LemonadeService } from '../http/lemonadeService';
import { Alert } from 'react-bootstrap';

function Order({items}: {items: lemonade[]}) {
    
    const [order, setOrder] = useState<order>({id: 0, items: [], total: 0, name: ''});
    const [total, setTotal] = useState(0);
    const [message, setMessage] = useState('');

    const updateOrder = (id: number, amount: number) => {
        const newOrder = {...order};
        let newItem = newOrder.items.find(i => i.lemonadeId === id);
        if (newItem)
        {
            if (amount > 0 || (amount < 0 && newItem.qty > 0))
            {
                newItem.qty += amount;
                newOrder.total += amount;
                newItem.total += amount;
            }
        }
        else
        {
            if (amount > 0) {
                newOrder.items.push({id: 0, lemonadeId: id, qty: amount, total: amount});
                newOrder.total += amount;
            }
        }
        
        console.log(newOrder);
        setOrder(newOrder);
        setTotal(newOrder.total);
    }

    const submitOrder = (name: string, email?: string, phone?: string) => {
        const newOrder = {...order};
        newOrder.name = name;
        newOrder.email = email;
        newOrder.phone = phone;
        const lemonadeService = new LemonadeService();

        lemonadeService.submitOrder(newOrder).then(v => {
            setMessage(`Order Complete. Your Order Number is: ${v}`);
        });
        // clear the order
        setOrder({id: 0, items: [], total: 0, name: ''});
        setTotal(0);
    }

    const removeItem = (id: number) => {
        const newOrder = {...order};
        let itemIndex = newOrder.items.findIndex(i => i.lemonadeId === id);
        if (itemIndex >= 0)
        {
            const item = newOrder.items[itemIndex];
            newOrder.total -= item.total;
            newOrder.items.splice(itemIndex, 1);
        }
        console.log(newOrder);
        setOrder(newOrder);
        setTotal(newOrder.total);
    }

    return (
        <div className="App-table">
            <OrderTable items={items} order={order} updateOrder={updateOrder} remove={removeItem} />
            <OrderSubmit total={total} submitOrder={submitOrder} />
            {message && (
                <Alert variant="success" onClose={() => setMessage('')} dismissible>{message}</Alert>
            )}
        </div>
    )
}

export default Order;