import orderitem from "./orderitem";

interface order {
    id: number;
    items: orderitem[];
    total: number;
    name: string;
    email?: string;
    phone?: string;
}

export default order;