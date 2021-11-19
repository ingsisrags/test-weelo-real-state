import { PRODUCT } from "./../Types"

const initialState = {
  product: [],
  trace:[],
  productonly:{}
}
export default function (state = initialState, action) {
  switch (action.type) {
    case PRODUCT.LOAD_PRODUCT:
      return {
        ...state,
        product: action.payload,
      };
    case PRODUCT.ADD_TRACE:
      return {
        ...state,
        trace: action.payload,
      };

      case PRODUCT.LOAD_PRODUCT_ID:
        return {
          ...state,
          productonly: action.payload,
        };
    default:
      return { state };

  }
}

