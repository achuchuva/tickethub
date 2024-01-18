import { Counter } from "./components/Counter";
import { FetchData } from "./components/FetchData";
import Home from "./components/Home";
import BookEvent from "./components/BookEvent";
import BookSuccess from "./components/BookSuccess";

const AppRoutes = [
  {
    index: true,
    element: <Home />
  },
  {
    path: '/counter',
    element: <Counter />
  },
  {
    path: '/fetch-data',
    element: <FetchData />
  },
  {
    path: '/events/:eventId',
    element: <BookEvent />
  },
  {
    path: '/orders/:orderId',
    element: <BookSuccess />
  },
];

export default AppRoutes;
