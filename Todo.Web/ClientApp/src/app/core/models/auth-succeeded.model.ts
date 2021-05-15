import { User } from "./index";

export interface AuthSucceeded {
  token: string;
  user: User;
}
