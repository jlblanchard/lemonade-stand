import React from 'react';
import lemonade from '../types/lemonade';
import lemon from '../images/lemon.png';
import minus from '../images/minus.png';
import plus from '../images/plus.png';
import trashcan from '../images/trashcan.png';
import { Button } from 'react-bootstrap';
import order from '../types/order';

function OrderTable({items, order, updateOrder, remove}: {items: lemonade[], order: order, updateOrder: (id: number, amount: number) => void, remove: (id: number) => void}) {
    return (
        <table style={{width: "50%"}}>
            <thead>
            <tr>
                <th/>
                <th/>
                <th>Price</th>
                <th>QTY</th>
                <th>Total</th>
                <th/>
            </tr>
            </thead>
            <tbody>
            {items.map(i => {
                const orderItem = order.items.find(oi => i.id === oi.lemonadeId);
                return (
                    <tr key={i.id}>
                        <td><img src={lemon} alt="lemon" /></td>
                        <td>
                            <p style={{fontSize: 20, fontWeight: 400, fontFamily: "Alice"}}>
                                {i.type.description === "Regular" ? "Lemonade" : `${i.type.description} Lemonade`}
                            </p>
                            <p style={{fontSize: 16, fontWeight: 400, fontFamily: "Alice", color:"#A2A2A2"}}>{i.size.description}</p>
                        </td>
                        <td>1.00</td>
                        <td>
                            <div style={{display: 'flex', justifyContent: 'center'}}>
                                <Button variant='outline-dark' className='App-qty' onClick={() => updateOrder(i.id, -1)}><img src={minus} /></Button>
                                {orderItem && orderItem.qty > 0 ? orderItem.qty : 0}
                                <Button variant='outline-dark' className='App-qty' onClick={() => updateOrder(i.id, 1)}><img src={plus} /></Button>
                            </div>
                        </td>
                        <td>
                            {orderItem ? new Intl.NumberFormat('en-US', {style: 'currency', currency: 'USD'}).format(orderItem.total) : new Intl.NumberFormat('en-US', {style: 'currency', currency: 'USD'}).format(0)}
                        </td>
                        <td>
                            <Button variant='light' onClick={() => remove(i.id)}><img src={trashcan}/></Button>
                        </td>
                    </tr>
                )
            })}
            </tbody>
        </table>
    )
}

export default OrderTable;