interface NumberResultPair {
    number: number;
    result: DivisibleBy;
}

type DivisibleBy = 'None' | 'Input1' | 'Input2' | 'Both';
