import axios from "axios";
import Globals from "./../Global/Globals"

export const getRangePrices = async () => {
    try {
        return await axios.get(`${Globals.BASE_URL_API}${Globals.API_PRODUCT}price/v1/get-price-range`)
    } catch (error) {
        console.log(error);
    }
}
