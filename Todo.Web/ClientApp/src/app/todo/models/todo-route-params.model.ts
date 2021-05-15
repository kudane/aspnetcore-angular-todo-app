import { TodoItem } from "../../core";
import { ShowTodoByLowerCaseEnum } from "./show-todo-by.model";

export interface TodoRouteParams {
  showBy: ShowTodoByLowerCaseEnum,
  todos: TodoItem[]
}
