// Fill out your copyright notice in the Description page of Project Settings.


#include "KSHealthComponent.h"
#include "Net/UnrealNetwork.h"


// Sets default values for this component's properties
UKSHealthComponent::UKSHealthComponent()
{
	
	MaxHealth = 100;
	bIsDead = false;

}


// Called when the game starts
void UKSHealthComponent::BeginPlay()
{
	Super::BeginPlay();

	Health = MaxHealth;

	AActor* MyOwner = GetOwner();
	if (MyOwner)
	{
		MyOwner->OnTakeAnyDamage.AddDynamic(this, &UKSHealthComponent::HandleTakeDamage);
	}
	
}

void UKSHealthComponent::HandleTakeDamage(AActor* DamagedActor, float Damage, const class UDamageType* DamageType, class AController* InstigatedBy, AActor* DamageCauser)
{
	if (Damage <= 0.0f || bIsDead)
	{
		return;
	}

	Health = FMath::Clamp(Health - Damage, 0.0f, MaxHealth);

	UE_LOG(LogTemp, Log, TEXT("Health Changed: %s"), *FString::SanitizeFloat(Health));

	bIsDead = Health <= 0.0f;

	OnHealthChanged.Broadcast(this, Health, Damage, DamageType, InstigatedBy, DamageCauser);

	//if (bIsDead)
	//{
	//}

}

float UKSHealthComponent::GetHealth() const
{
	return Health;
}

void UKSHealthComponent::GetLifetimeReplicatedProps(TArray<FLifetimeProperty>& OutLifetimeProps) const
{
	Super::GetLifetimeReplicatedProps(OutLifetimeProps);

	DOREPLIFETIME(UKSHealthComponent, Health);
}