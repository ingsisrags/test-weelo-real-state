import axios from "axios";
import Globals from './../Global/Globals'



const endPointData = axios.create({
    baseURL: `${Globals.BASE_URL_API}${Globals.API_PRODUCT}`,
});

endPointData.defaults.headers.common["Accept"] = "aplication/json";

export default endPointData;
