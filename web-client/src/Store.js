import { createStore, applyMiddleware, compose } from "redux";
import thunk from "redux-thunk";
import reducer from "./Modules/Reducers";

const composeEnhancer =
  (process.env.NODE_ENV !== "production" &&
    window.__REDUX_DEVTOOLS_EXTENSION_COMPOSE__) ||
  compose;


const store = createStore(
  reducer,
   composeEnhancer(applyMiddleware(thunk))
);

store.subscribe(() => {
  sessionStorage.setItem("state", JSON.stringify(store.getState()));
});


export default store;
