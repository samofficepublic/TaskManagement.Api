import { createStore, combineReducers, applyMiddleware } from "redux";
import Login_Reducer from "./ReduxLogin/Login_Reducer";
import Ticket_Reducer from "./ReduxTicket/Ticket_Reducer";
import thunk from "redux-thunk";

const reducer = combineReducers({
  Login_Reducer,
  Ticket_Reducer
});

const MainStore = createStore(reducer, applyMiddleware(thunk));

export default MainStore;
