import Home from "./components/Home";
import BookEvent from "./components/BookEvent";
import BookSuccess from "./components/BookSuccess";

const AppRoutes = [
  {
    index: true,
    element: <Home />
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
