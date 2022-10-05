import React, { useState } from 'react';
import {Form, Button, Alert } from 'react-bootstrap';

function OrderSubmit({total, submitOrder}: {total: number, submitOrder: (name: string, email?: string, phone?: string) => void})
{
    const [invalid, setInvalid] = useState(false);
    const [name, setName] = useState('');
    const [email, setEmail] = useState('');
    const [phone, setPhone] = useState('');

    const handleSubmit = (event: any) => {
        event.preventDefault();
        event.stopPropagation();
        if (name && (email || phone) && total > 0) {
            // Submit
            submitOrder(name, email, phone);
            setInvalid(false);
        } else {
            setInvalid(true);
        }
    }

    const handleNameChange = (event: any) => {
        setName(event.target.value);
    }

    const handleEmailChange = (event: any) => {
        setEmail(event.target.value);
    }

    const handlePhoneChange = (event: any) => {
        setPhone(event.target.value);
    }

    return (
        <div>
            <Form noValidate onSubmit={handleSubmit}>
                <Form.Group className='mb-3' controlId='formBasicName'>
                    <Form.Label>Name</Form.Label>
                    <Form.Control type='text' placeholder='name' onChange={handleNameChange}/>
                </Form.Group>
                <Form.Group className='mb-3' controlId='formBasicEmail'>
                    <Form.Label>Email</Form.Label>
                    <Form.Control type='email' onChange={handleEmailChange}/>
                </Form.Group>
                <Form.Group className='mb-3' controlId='formBasicPhone'>
                    <Form.Label>Phone Number</Form.Label>
                    <Form.Control type='text' onChange={handlePhoneChange}/>
                </Form.Group>
                <div>
                    <p>Total</p>
                    <p>{new Intl.NumberFormat('en-US', {style: 'currency', currency: 'USD'}).format(total)}</p>
                </div>
                <Button variant="dark" type="submit">Order Now</Button>
            </Form>
            {invalid && (
                <Alert variant="danger" onClose={() => setInvalid(false)} dismissible>
                    {total > 0 ? 'You must supply a name and email or phone number to complete an order' : 'You must add at least 1 item to the order'}
                </Alert>
            )}
        </div>
    )
}

export default OrderSubmit;