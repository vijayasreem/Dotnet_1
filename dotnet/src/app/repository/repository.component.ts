package com.example.mortgage;

import java.util.Scanner;

public class MortgageCalculator {
  public static void main(String[] args) {
    Scanner scanner = new Scanner(System.in);

    System.out.print("Enter loan amount: ");
    double loanAmount = scanner.nextDouble();

    System.out.print("Enter interest rate: ");
    double interestRate = scanner.nextDouble();

    System.out.print("Enter loan term (in years): ");
    int loanTerm = scanner.nextInt();

    double monthlyInterestRate = interestRate / 12 / 100;
    int numberOfPayments = loanTerm * 12;

    double monthlyPayment = (loanAmount * monthlyInterestRate) /
        (1 - Math.pow(1 + monthlyInterestRate, -numberOfPayments));

    double totalPayment = monthlyPayment * numberOfPayments;
    double totalInterest = totalPayment - loanAmount;

    System.out.println("Monthly Payment: " + monthlyPayment);
    System.out.println("Total Payment: " + totalPayment);
    System.out.println("Total Interest: " + totalInterest);

    scanner.close();
  }
}