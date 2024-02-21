import { Pipe, PipeTransform } from "@angular/core";

@Pipe({ name: 'yesNoResult', standalone: true})
export class YesNoResultPipe implements PipeTransform {
    static map: Record<DivisibleBy, string> = {
      Input1: 'yes',
      Input2: 'no',
      Both: 'I don\'t know',
      None: ''
    }

    transform(value: DivisibleBy): string {
        return YesNoResultPipe.map[value];
    }
}
