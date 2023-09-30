import axios from "axios";

export default {
    url: 'https://localhost:44315/',
    getpizzas(store){
        axios.get(`${this.url}Pizza`).then((response) => {
            store.commit('GETPIZZAS', response.data)
        })
    },
    getsides(store){
        axios.get(`${this.url}Side`).then((response) => {
            store.commit('GETSIDES', response.data)
        })
    },
    getdrinks(store){
        axios.get(`${this.url}Drink`).then((response) => {
            store.commit('GETDRINKS', response.data)
        })
    },
    getwings(store){
        axios.get(`${this.url}Wing`).then((response) => {
            store.commit('GETWINGS', response.data)
        })
    },
    getsizes(store){
        axios.get(`${this.url}Size`).then((response) => {
            store.commit('GETSIZES', response.data)
        })
    }
}