import axios from "axios";
export default{
    url: 'https://localhost:44315/',
    async submitAddressGetID(store){
        let output = await axios.post(this.url + 'Address', store.state.address)
        return output
    },
    async submitPaymentGetID(store){
        store.state.payment.expDate = store.state.payment.expDate + '-17T17:11:55.510Z'
        let output = await axios.post(this.url + 'Payment', store.state.payment)
        return output
    },
    async submitOrder(store){
        await axios.post(this.url + 'Order', store.state.order)
    }
}