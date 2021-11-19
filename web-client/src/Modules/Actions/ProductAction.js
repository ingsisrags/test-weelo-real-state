import { PRODUCT } from "../Types"
import Globals from "../../Global/Globals"
import endPointData from "../../Axios/Axios";
import { Form } from "reactstrap";



export const LoadProduct = (data) => {
  return {
    type: PRODUCT.LOAD_PRODUCT,
    payload: data
  }
};


export const LoadProductOnly = (data) => {
  return {
    type: PRODUCT.LOAD_PRODUCT_ID,
    payload: data
  }
};

export const AddTrace = (data) => {
  return {
    type: PRODUCT.ADD_TRACE,
    payload: data
  }
}

export function UpdatePriceId(id, price)  {
  console.log("update price redux", id, price)
  try {
    return async (dispatch) => {
    const response = await endPointData.put("price/v1/change-price-property/", {propertyId: id, price: price})
    }
  } catch (error) {
      console.log(error);
  }
}

export function getProduct(id)  {
  console.log("getproductid", id)
  try {
    return async (dispatch) => {
    const response = await endPointData.get("property/v1/get-property-by-id/${id}")
    dispatch(LoadProductOnly(response.data));
    }
  } catch (error) {
      console.log(error);
  }
}

export function readProducts(numberPage, keyWord, priceMin, priceMax) {

  try {
    const million = 1000000;
    return async (dispatch) => {
      console.log(keyWord);
      var endPointRead = `property/v1/get-properties?PageNumber=${numberPage}&PageSize=6`;
      if (priceMin > 0) {
        endPointRead = `${endPointRead}&MinimumPrice=${priceMin * million}`;
      }

      if (priceMax > 0) {
        endPointRead = `${endPointRead}&MaximumPrice=${priceMax * million}`;
      }

      if (keyWord?.length > 0) {
        endPointRead = `${endPointRead}&keyWord=${keyWord}`;
      }
      const response = await endPointData.get(endPointRead)
      dispatch(LoadProduct(response.data));
    }
  } catch (error) {
    console.log(error);
  }
}

export function AddList(data) {
  return async (dispatch) => {
    dispatch(AddTrace(data));
  }
}

export function createProperty(property) {
  try {
    console.log('entry create produtt', property)
    return async (dispatch) => {
      var formData = new FormData();
      formData.append("Image", property.image);
      var response =  await endPointData.post("property/v1/create-property", property)

      formData.append("PropertyId", response.data.id);
       await endPointData.post("property/v1/create-image-property",formData)

    }
  } catch (error) {
    console.log(error);
  }
}

export function CreateOwner(numberPage, keyWord, priceMin, priceMax) {
  var endPointRead = `${Globals.BASE_URL_API}${Globals.API_PRODUCT}property/v1/get-properties?PageNumber=${numberPage}&PageSize=6`;
}