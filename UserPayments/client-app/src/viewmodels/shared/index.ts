import type { ResponseBaseTypeEnum } from "@/utilities/shared/enums";

export interface ResponseBase<T> {
  Type: ResponseBaseTypeEnum;
  Messages: string[];
  Result: T;
}
