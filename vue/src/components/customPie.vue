<template>
  <div class="main-container">
    <div class="custom-pizza-container">
      <div><h1>Custom Pizza Builder</h1></div>
      <div class="size">
        <h2>Select Size:</h2>
        <div class="size-option" v-for="size in pizzaSizes" :key="size.id">
          <checkbox-component v-model="outputPizza.size" :label="size.name" />
          <span class="size-icon">
            <i :class="size.iconClass"></i>
          </span>
        </div>
      </div>
      <div>
        <h2>Select Crust:</h2>
        <checkbox-component v-model="selectedCrust" label="Thin" />
        <checkbox-component v-model="selectedCrust" label="Thicc" />
        <checkbox-component v-model="selectedCrust" label="Pretzel" />
        <checkbox-component v-model="selectedCrust" label="Stuffed" />
        <checkbox-component v-model="selectedCrust" label="Normal" />
      </div>
      <div>
        <h2>Select Cheese:</h2>
        <checkbox-component v-model="selectedCheese" label="Mozzarella" />
        <checkbox-component v-model="selectedCheese" label="Cheddar" />
        <checkbox-component v-model="selectedCheese" label="Gouda" />
        <checkbox-component v-model="selectedCheese" label="Provolone" />
        <checkbox-component v-model="selectedCheese" label="Parmesan" />
        <checkbox-component v-model="selectedCheese" label="PepperJack" />
      </div>
      <div>
        <h2>Select Sauce:</h2>
        <checkbox-component v-model="selectedSauce" label="Red" />
        <checkbox-component v-model="selectedSauce" label="White" />
        <checkbox-component v-model="selectedSauce" label="None" />
      </div>
      <div>
        <h2>Select Toppings</h2>
        <div v-for="topping in toppings" :key="topping.id">
          <checkbox-component
            v-model="selectedToppings"
            :label="topping.name"
          />
        </div>
        <!-- Add a button to submit the custom pizza order -->
      </div>
    </div>
  </div>
</template>

<script>
import CheckboxComponent from "@/components/CheckboxComponent.vue";

export default {
  name: "custom-pizza",
  components: {
    CheckboxComponent,
  },
  data() {
    return {
      pizzaSizes: [
        { id: 1, name: "Small", iconClass: "fas fa-circle", price: 8},
        { id: 2, name: "Medium", iconClass: "fas fa-circle bigger-icon", price: 12 },
        { id: 3, name: "Large", iconClass: "fas fa-circle even-bigger-icon", price: 15 },
      ],
      pizza: {
        crustID: 0,
        pizzaName: "string",
        userID: 0,
        isFavorited: false,
        isVegetarian: false,
        isGlutenFree: false,
        sauceID: 0,
        toppings: [
          {
            toppingId: 0,
            isExtra: false,
            quad1: true,
            quad2: true,
            quad3: true,
            quad4: true,
          },
        ],
        cheeseIDs: [],
      },
      newPizza: {
        itemKey: 0,
        pizza: 1,
        name: "Custom Pizza",
        price: this.price + this.outputSize.price,
      },
      outputPizza: { pizza: 1, size: 2 }
    };
  },
};
</script>

<style scoped>
.mainContainer {
  display: flex;
  align-items: center;
  justify-content: center;
  min-height: 100vh;
}

.custom-pizza-container {
  background-color: white;
  background-image: url("/public/img/headTransparent.png");
  background-repeat: repeat;
  border-radius: 10px;
  box-shadow: 0px 15px 30px 20px rgba(0, 0, 0, 0.4);
  padding: 20px;
  width: 75vw;
  max-width: 900px;
  margin: 50px;
}
h1 {
  text-align: center;
  margin-bottom: 20px;
  font-size: 50px;
  color: rgb(7, 128, 13);
  font-family: "TurtlesFont", sans-serif;
  text-shadow: 2.5px 1px #af0808;
}
h2 {
  justify-content: center;
}
.size-option {
  display: flex;
  align-items: center;
  margin-bottom: 10px;
}
.size {
  display: flex;
  flex-direction: row;
  justify-content: space-between;
}

.bigger-icon {
  font-size: 45px;
}

.even-bigger-icon {
  font-size: 60px;
}
</style>

