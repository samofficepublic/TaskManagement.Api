import { createStore, combineReducers, applyMiddleware } from "redux";
import Login_Reducer from "./ReduxLogin/Login_Reducer";
import thunk from "redux-thunk";

const reducer = combineReducers({
  Login_Reducer
});

const MainStore = createStore(reducer, applyMiddleware(thunk));

export default MainStore;
