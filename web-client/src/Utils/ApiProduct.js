import axios from "axios";
import Globals from "./../Global/Globals"
export const getProducts = async () => {
    try {
        return await axios.get(`${Globals.BASE_URL_API}${Globals.API_PRODUCT}property/v1/get-properties?PageNumber=1&PageSize=6`)
    } catch (error) {
        console.log(error);
    }
}

export const getProduct = async (id) => {
    try {
       return await axios.get(`${Globals.BASE_URL_API}${Globals.API_PRODUCT}property/v1/get-property-by-id/${id}`)
    } catch (error) {
        console.log(error);
    }
}
